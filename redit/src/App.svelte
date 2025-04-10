<script lang="ts">
  import { writable } from 'svelte/store';

  type RoomNode = {
    id: string;
    name: string;
    description: string;
    tags: string;
    position: { x: number; y: number };
  };

  type Connection = {
    from: string;
    to: string;
  };

  const nodes = writable<RoomNode[]>([]);
  const connections = writable<Connection[]>([]);
  const selectedNode = writable<RoomNode | null>(null);

  function addNode() {
    nodes.update(current => {
      const newNode: RoomNode = {
        id: `room_${current.length + 1}`,
        name: 'New Room',
        description: 'Room description...',
        tags: '',
        position: { x: 100 + current.length * 50, y: 100 },
      };
      return [...current, newNode];
    });
  }

  function selectNode(node: RoomNode) {
    selectedNode.set(node);
  }

  function exportJson() {
    let exportData: { rooms: any[]; connections: Connection[] } = { rooms: [], connections: [] };

    nodes.subscribe(n => {
      exportData.rooms = n.map(node => ({
        id: node.id,
        name: node.name,
        description: node.description,
        tags: node.tags.split(',').map(tag => tag.trim()),
      }));
    })();

    connections.subscribe(c => {
      exportData.connections = c;
    })();

    const blob = new Blob([JSON.stringify(exportData, null, 2)], { type: 'application/json' });
    const link = document.createElement('a');
    link.href = URL.createObjectURL(blob);
    link.download = 'world_export.json';
    link.click();
  }
</script>

<style>
  .editor {
    display: flex;
    gap: 20px;
  }

  .canvas {
    flex-grow: 1;
    position: relative;
    border: 1px solid #ccc;
    height: 600px;
  }

  .node {
    position: absolute;
    background: #f9f9f9;
    border: 1px solid #ccc;
    padding: 10px;
    cursor: pointer;
    border-radius: 5px;
    box-shadow: 2px 2px 5px rgba(0, 0, 0, 0.1);
  }

  .inspector {
    width: 300px;
    border: 1px solid #ccc;
    padding: 10px;
  }
</style>

<div class="editor">
  <div>
    <button on:click={addNode}>Add Room</button>
    <button on:click={exportJson}>Export JSON</button>
  </div>

  <div class="canvas">
    {#each $nodes as node (node.id)}
      <div
        class="node"
        style="left: {node.position.x}px; top: {node.position.y}px"
        on:click={() => selectNode(node)}
      >
        <strong>{node.name}</strong>
      </div>
    {/each}
  </div>

  {#if $selectedNode}
    <div class="inspector">
      <h3>Edit Room</h3>
      <label>ID: <input bind:value={$selectedNode.id} /></label><br />
      <label>Name: <input bind:value={$selectedNode.name} /></label><br />
      <label>Description:<br /><textarea bind:value={$selectedNode.description}></textarea></label><br />
      <label>Tags (comma separated):<br /><input bind:value={$selectedNode.tags} /></label>
    </div>
  {/if}
</div>
