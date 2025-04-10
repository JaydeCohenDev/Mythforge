import { createNoise2D, type NoiseFunction2D } from 'simplex-noise';

export interface INode {
    id: string;
    position: {
        x: number;
        y: number;
    };
    biome?: string;
}

export interface IEdge {
    id: string;
    source: string;
    target: string;
}

export interface IWorld {
    nodes: INode[];
    edges: IEdge[];
}

export interface GenerateMSTOptions {
    extraConnectionChance?: number; // chance between 0 and 1
}

export interface INode {
    id: string;
    position: {
        x: number;
        y: number;
    };
}

export interface IEdge {
    id: string;
    source: string;
    target: string;
}

export interface IWorld {
    nodes: INode[];
    edges: IEdge[];
}

export interface GenerateMSTOptions {
    extraConnectionChance?: number; // chance between 0 and 1
    cellSize?: number; // for spatial optimization
}

// Calculate Euclidean distance
export function calculateDistance(pos1: { x: number; y: number }, pos2: { x: number; y: number }): number {
    const dx = pos1.x - pos2.x;
    const dy = pos1.y - pos2.y;
    return Math.sqrt(dx * dx + dy * dy);
}

export function createSeededRandom(seed: number) {
    let value = seed;
    return function random() {
        value = (value * 9301 + 49297) % 233280;
        return value / 233280;
    };
}



export function createSeededNoise(seed: number) {
    const rand = createSeededRandom(seed);
    return createNoise2D(rand);
}

function addExtraDelaunayEdges(allEdges: Edge[], mstEdges: Edge[], extraConnectionChance: number, rand: () => number): Edge[] {
    const mstEdgeSet = new Set(mstEdges.map(e => [e.source, e.target].sort().join("-")));

    const extraEdges: Edge[] = [];

    for (const edge of allEdges) {
        const key = [edge.source, edge.target].sort().join("-");
        if (!mstEdgeSet.has(key) && rand() < extraConnectionChance) {
            mstEdgeSet.add(key);
            extraEdges.push(edge);
        }
    }

    return extraEdges;
}

import { computeDelaunayEdges, computeMST, type Edge } from './delaunay';
import GenerateWorldWorker from './generateWorld.worker?worker';

export function generateWorldAsync(seed: number, nodeCount: number, areaSize: number, minSpacing: number, extraConnectionChance: number): Promise<IWorld> {
    return new Promise((resolve) => {
        const worker = new GenerateWorldWorker();

        worker.postMessage({ seed, nodeCount, areaSize, minSpacing, extraConnectionChance });

        worker.onmessage = function (event) {
            resolve(event.data);
            worker.terminate();
        };
    });
}

const BIOME_TYPES = ["forest", "plains", "mountains", "swamp"]

function generateBiomeSeeds(seedCount: number, areaSize: number, rand: () => number): { x: number, y: number, biome: string }[] {
    const seeds = [];

    for (let i = 0; i < seedCount; i++) {
        seeds.push({
            x: rand() * areaSize,
            y: rand() * areaSize,
            biome: BIOME_TYPES[Math.floor(rand() * BIOME_TYPES.length)]
        });
    }

    return seeds;
}

function assignVoronoiBiomes(nodes: INode[], biomeSeeds: { x: number, y: number, biome: string }[]): Map<string, string> {
    const nodeBiomes = new Map<string, string>();

    nodes.forEach(node => {
        let closestSeed = biomeSeeds[0];
        let closestDistance = Infinity;

        for (const seed of biomeSeeds) {
            const dx = node.position.x - seed.x;
            const dy = node.position.y - seed.y;
            const distSq = dx * dx + dy * dy;

            if (distSq < closestDistance) {
                closestDistance = distSq;
                closestSeed = seed;
            }
        }

        nodeBiomes.set(node.id, closestSeed.biome);
        node.biome = closestSeed.biome;
    });

    return nodeBiomes;
}

function generateNodes(count: number, areaSize: number, minSpacing: number, rand: () => number, noise: NoiseFunction2D, landThreshold = 0): INode[] {
    const nodes: INode[] = [];
    const grid = new Map<string, INode[]>();

    const cellSize = minSpacing;
    const gridKey = (x: number, y: number) => `${Math.floor(x / cellSize)},${Math.floor(y / cellSize)}`;

    function isTooClose(x: number, y: number): boolean {
        const gx = Math.floor(x / cellSize);
        const gy = Math.floor(y / cellSize);

        for (let dx = -1; dx <= 1; dx++) {
            for (let dy = -1; dy <= 1; dy++) {
                const key = `${gx + dx},${gy + dy}`;
                const candidates = grid.get(key);
                if (candidates) {
                    for (const candidate of candidates) {
                        const dx = candidate.position.x - x;
                        const dy = candidate.position.y - y;
                        if (Math.sqrt(dx * dx + dy * dy) < minSpacing) {
                            return true;
                        }
                    }
                }
            }
        }
        return false;
    }

    let attempts = 0;
    const maxAttempts = count * 20; // reasonable number

    while (nodes.length < count && attempts < maxAttempts) {
        const x = rand() * areaSize;
        const y = rand() * areaSize;
        attempts++;

        // Check landmass noise
        const nx = x / areaSize - 0.5;
        const ny = y / areaSize - 0.5;
        const distFromCenter = Math.sqrt(nx * nx + ny * ny);

        // Inverse mask: closer to center = higher
        const islandFactor = Math.pow(1.0 - distFromCenter * 2, 3);

        const elevation = noise(nx * 4, ny * 4);


        if (elevation < landThreshold) continue; // Water: skip

        if (isTooClose(x, y)) {
            continue;
        }

        const node: INode = {
            id: `Node:${nodes.length}`,
            position: { x, y }
        };

        nodes.push(node);

        const key = gridKey(x, y);
        if (!grid.has(key)) grid.set(key, []);
        grid.get(key)!.push(node);
    }

    if (nodes.length < count) {
        console.warn(`Warning: Only generated ${nodes.length} nodes out of requested ${count}. Try reducing minSpacing or increasing areaSize.`);
    }

    return nodes;
}



export function generateWorld(seed: number, nodeCount: number, areaSize: number, minSpacing: number, extraConnectionChance: number): IWorld {
    console.log(`Generating world with seed: ${seed}, nodeCount: ${nodeCount}, areaSize: ${areaSize}, minSpacing: ${minSpacing}, extraConnectionChance: ${extraConnectionChance}`);

    const rand = createSeededRandom(seed);
    console.log("Seeded random generator created.");

    const noise = createSeededNoise(seed);

    const nodes = generateNodes(nodeCount, areaSize, minSpacing, rand, noise, -0.25);
    console.log(`Generated ${nodes.length} nodes.`);

    const biomeSeedCound = 20;
    const biomeSeeds = generateBiomeSeeds(biomeSeedCound, areaSize, rand);
    const biomes = assignVoronoiBiomes(nodes, biomeSeeds);


    const delaunayEdges = computeDelaunayEdges(nodes);
    console.log(`Computed ${delaunayEdges.length} Delaunay edges.`);

    const mstEdges = computeMST(nodes, delaunayEdges);
    console.log(`Computed Minimum Spanning Tree with ${mstEdges.length} edges.`);

    const extraEdges = addExtraDelaunayEdges(delaunayEdges, mstEdges, extraConnectionChance, rand);
    console.log(`Added ${extraEdges.length} extra edges based on extraConnectionChance.`);

    const allEdges = [...mstEdges, ...extraEdges];
    console.log(`Total edges in the world: ${allEdges.length}`);

    const world: IWorld = {
        nodes,
        edges: allEdges.map((edge, index) => ({
            id: `Edge:${index}`,
            source: nodes[edge.source].id,
            target: nodes[edge.target].id
        }))
    };

    console.log("World generation complete.");
    return world;
}
