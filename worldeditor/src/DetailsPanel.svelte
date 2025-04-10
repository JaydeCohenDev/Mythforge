<script lang="ts">
    import cytoscape from "cytoscape";
    import { onMount } from "svelte";
    import Property from "./Property.svelte";

    //cytoscape.Core
    const { cy }: { cy: cytoscape.Core } = $props();

    var data: string = $state("");
    var selectedItem;

    onMount(() => {
        cy.on("unselect", (e) => {
            data = "";
        });
        cy.on("select", "node", (e) => {
            data = JSON.stringify(e.target.json());
        });
        cy.on("select", "edge", (e) => {
            data = JSON.stringify(e.target.json());
        });
    });
</script>

<div class="details">{data}<Property /></div>

<style>
    .details {
        color: white;
        position: absolute;
        right: 0;
        top: 0;
        bottom: 0;
        width: 400px;
        background-color: black;
    }
</style>
