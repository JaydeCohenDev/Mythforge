<script lang="ts">
    import Icon from '../assets/images/icon_farm_01.jpg';

    const { room } = $props();
</script>

<div class="marker" style="background-image: url({Icon});">
    {room ? room.Name : 'unknown'}
</div>

<style>
    .marker {
        width: 100%;
        height: 100%;

        background-size: contain;
        border-radius: 50%;

        text-align: center;
        display: flex;
        justify-content: center;
        align-items: center;
        color: transparent;
    }
</style>
