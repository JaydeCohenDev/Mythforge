// generateWorld.worker.ts

import { generateWorld, type IWorld } from './worldgen';

self.onmessage = function (event) {
    const { seed, nodeCount, areaSize, minSpacing, extraConnectionChance } = event.data as { seed: number, nodeCount: number, areaSize: number, minSpacing: number, extraConnectionChance: number };

    const mstWorld = generateWorld(seed, nodeCount, areaSize, minSpacing, extraConnectionChance);

    self.postMessage(mstWorld);
};