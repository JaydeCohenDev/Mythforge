<script lang="ts">
    import { onMount } from "svelte";
    import cytoscape from "cytoscape";
    import { generateWorld, generateWorldAsync } from "./lib/worldgen";

    var appEl: HTMLElement;

    onMount(async () => {
        const cy = cytoscape({
            container: appEl,
        });

        console.log("Generating world...");
        const world = await generateWorldAsync(1234, 500, 5000, 150, 0.25);

        const biomeColors = {
            forest: "MediumSeaGreen",
            plains: "Orange",
            mountains: "Gray",
            swamp: "#808000",
        };

        for (const node of world.nodes) {
            cy.add({
                data: {
                    id: node.id,
                },
                position: node.position,
                style: {
                    "background-color": biomeColors[node.biome],
                },
            });
        }

        for (const edge of world.edges) {
            cy.add({
                data: {
                    ...edge,
                },
            });
        }

        // cy.layout({
        //     name: "cose",
        //     animate: true,
        //     animationThreshold: 250,
        //     refresh: 20,
        //     randomize: false,
        // }).start();
    });
</script>

<div bind:this={appEl} id="app"></div>

<style>
    #app {
        width: 100vw;
        height: 100vh;
        overflow: hidden;
    }
</style>
