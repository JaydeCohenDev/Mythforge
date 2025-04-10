<script lang="ts">
    import { setCursor } from '../../lib/cursor';

    const { options, callback } = $props();
</script>

{#each JSON.parse(options).Options as option}
    <a use:setCursor={'pointer'} class="option" onclick={() => callback(option)}>[ {option} ]</a>
{/each}

<style>
    .option {
        pointer-events: all;
        color: cyan;
        font-weight: bold;
        text-transform: uppercase;
    }
    .option:hover {
        text-decoration: underline;
    }
</style>
