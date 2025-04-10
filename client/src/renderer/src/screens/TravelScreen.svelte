<script lang="ts">
    import { onMount } from 'svelte';
    import Map from '../panels/Map.svelte';
    import { connect } from '../lib/connect';

    var region = $state(undefined);

    onMount(async () => {
        const connection = await connect();
        connection.invoke('GetRegion', 'amberfall').then((data) => {
            region = JSON.parse(data).data;
        });
    });
</script>

<div>
    <Map {region} />
</div>
