<script lang="ts">
    import { onMount } from 'svelte';

    const { content } = $props();

    var el: HTMLElement;

    onMount(() => {
        const mouseMove = (e: MouseEvent) => {
            el.style.top = `${e.clientY - el.clientHeight - 10}px`;
            el.style.left = `${e.clientX + 10}px`;
        };

        window.addEventListener('mousemove', mouseMove);

        return () => {
            window.removeEventListener('mousemove', mouseMove);
        };
    });
</script>

<div bind:this={el} class="tooltip">
    {@html content}
</div>

<style>
    .tooltip {
        color: white;
        pointer-events: none;
        position: absolute;
        border: 1px solid #222;
        top: 0;
        left: 0;
        width: 300px;
        padding: 20px;
        background-color: #111;
        box-shadow: 0px 0px 20px rgba(0, 0, 0, 0.5);
        z-index: 100;
    }
</style>
