import { Delaunay } from "d3-delaunay";
import { type INode, calculateDistance } from "./worldgen";

export interface Edge {
    source: number;
    target: number;
    weight: number;
}

export function computeDelaunayEdges(nodes: INode[]): Edge[] {
    const points: Array<[number, number]> = nodes.map(node => [node.position.x, node.position.y] as [number, number]);
    const delaunay = Delaunay.from(points);

    const edges = new Set<string>();
    const edgeList: Edge[] = [];

    for (let e = 0; e < delaunay.halfedges.length; e++) {
        const r = delaunay.halfedges[e];
        if (r < e) continue; // Avoid duplicates

        const sourceIndex = delaunay.triangles[e];
        const targetIndex = delaunay.triangles[(e % 3 === 2) ? e - 2 : e + 1];

        const source = nodes[sourceIndex];
        const target = nodes[targetIndex];

        const key = [sourceIndex, targetIndex].sort().join("-");
        if (edges.has(key)) continue;

        edges.add(key);

        const weight = calculateDistance(source.position, target.position);
        edgeList.push({ source: sourceIndex, target: targetIndex, weight });
    }

    return edgeList;
}

export function computeMST(nodes: INode[], edges: Edge[]): Edge[] {
    const parent = Array(nodes.length).fill(0).map((_, i) => i);

    function find(u: number): number {
        if (parent[u] !== u) parent[u] = find(parent[u]);
        return parent[u];
    }

    function union(u: number, v: number): boolean {
        const rootU = find(u);
        const rootV = find(v);
        if (rootU === rootV) return false;
        parent[rootV] = rootU;
        return true;
    }

    const mst: Edge[] = [];

    edges.sort((a, b) => a.weight - b.weight);

    for (const edge of edges) {
        if (union(edge.source, edge.target)) {
            mst.push(edge);
        }
    }

    return mst;
}