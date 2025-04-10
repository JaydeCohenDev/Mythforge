<script lang="ts">
    import cytoscape from "cytoscape";
    import edgehandles from "cytoscape-edgehandles";
    import contextMenus from "cytoscape-context-menus";
    import "cytoscape-context-menus/cytoscape-context-menus.css";
    import DetailsPanel from "./DetailsPanel.svelte";
    import type { WorldData } from "./lib/WorldData";
    import type { NodeDefinition } from "cytoscape";

    import "svelte-material-ui/bare.css";
    import "svelte-material-ui/themes/material-dark.css";

    var cy: cytoscape.Core;

    const createGraph = (el: HTMLElement) => {
        cy = cytoscape({
            container: el,

            layout: {
                name: "grid",
                rows: 1,
            },

            selectionType: "single",
        });

        var saveData = window.localStorage.getItem("world");
        if (saveData) {
            var world = JSON.parse(saveData);

            cy.json(world);
        }

        cy.on("select", "edge", (e) => {
            console.log("Edge selected:", e.target.id());
        });

        cytoscape.use(edgehandles);
        cytoscape.use(contextMenus);

        // the default values of each option are outlined below:
        let defaults: edgehandles.EdgeHandlesOptions = {
            canConnect: function (sourceNode: any, targetNode: any) {
                // whether an edge can be created between source and target
                return !sourceNode.same(targetNode); // e.g. disallow loops
            },
            edgeParams: function (sourceNode: any, targetNode: any) {
                // for edges between the specified source and target
                // return element object to be passed to cy.add() for edge
                return {};
            },
            hoverDelay: 150, // time spent hovering over a target node before it is considered selected
            snap: false, // when enabled, the edge can be drawn by just moving close to a target node (can be confusing on compound graphs)
            snapThreshold: 50, // the target node must be less than or equal to this many pixels away from the cursor/finger
            snapFrequency: 15, // the number of times per second (Hz) that snap checks done (lower is less expensive)
            noEdgeEventsInDraw: true, // set events:no to edges during draws, prevents mouseouts on compounds
            disableBrowserGestures: true, // during an edge drawing gesture, disable browser gestures such as two-finger trackpad swipe and pinch-to-zoom
        };

        let eh = cy.edgehandles(defaults);
        var ctx = cy.contextMenus({
            menuItems: [
                {
                    id: "remove", // ID of menu item
                    content: "remove", // Display content of menu item
                    tooltipText: "remove", // Tooltip text for menu item
                    // Filters the elements to have this menu item on cxttap
                    // If the selector is not truthy no elements will have this menu item on cxttap
                    selector: "node, edge",
                    onClickFunction: function () {
                        // The function to be executed on click
                        console.log("remove element");
                    },
                    disabled: false, // Whether the item will be created as disabled
                    show: true, // Whether the item will be shown or not
                    hasTrailingDivider: true, // Whether the item will have a trailing divider
                    coreAsWell: false, // Whether core instance have this item on cxttap
                    submenu: [], // Shows the listed menuItems as a submenu for this item. An item must have either submenu or onClickFunction or both.
                },
            ],
        });

        console.log(cy.json());

        var drawMode = false;
        var isAddMode = false;

        cy.on("select", "node", (e) => {
            console.log(e.target.json());
        });

        cy.on("click", (e) => {
            if (e.target === cy && isAddMode) {
                cy.add({
                    // node a
                    data: {
                        id: Math.random().toString(),
                    },
                    position: e.position,
                });
                console.log("asdf");
            }
        });

        window.onkeydown = (e) => {
            if (e.key === "Delete" || e.key === "Backspace") {
                cy.$(":selected").remove();
                return;
            }

            if (e.key === "a") {
                isAddMode = true;
                return;
            }

            if (e.key === "Shift") {
                if (!drawMode) {
                    drawMode = true;
                    eh.enableDrawMode();
                    console.log("draw enabled");
                }
                return;
            }
        };

        window.onkeyup = (e) => {
            if (e.key === "Shift") {
                if (drawMode) {
                    drawMode = false;
                    eh.disableDrawMode();
                    console.log("draw disabled");
                }
                return;
            }

            if (e.key === "a") {
                isAddMode = false;
                return;
            }
        };

        setInterval(() => {
            var data: WorldData = {
                //nodes: cy.json()
            };

            window.localStorage.setItem("world", JSON.stringify(cy.json()));
        }, 1000);
    };
</script>

<div use:createGraph id="graph"></div>
<DetailsPanel {cy} />

<style>
    #graph {
        width: 100vw;
        height: 100vh;
    }

    :global(body) {
        margin: 0;
        background-color: #111;
        width: 100vw;
        height: 100vh;
        overflow: hidden;
    }
</style>
