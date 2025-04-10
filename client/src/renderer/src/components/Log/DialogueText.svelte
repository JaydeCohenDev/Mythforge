<script lang="ts">
    const { data, children } = $props();
</script>

<span
    ><span class="sayer">{data.SayerName}</span> <span class="method">{data.SayMethod}</span>
    <span class="dialogue">“{data.Message}”</span></span
>{@render children?.()}

<style>
    .method {
        color: gray;
    }
    .dialogue {
        color: cyan;
        font-style: italic;
        text-decoration-style: none;
    }
</style>
