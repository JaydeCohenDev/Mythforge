<script lang="ts">
    // import { onMount } from 'svelte';
    // import { connect } from './lib/connect';
    import MessageLog from './panels/MessageLog.svelte';
    import Cursor from './components/Cursor.svelte';
    // import type { HubConnection } from '@microsoft/signalr';

    // var con: HubConnection | undefined;

    // const reconnect = () => {
    //     connect().then((c) => {
    //         con = c;
    //     });
    // };

    // onMount(async () => {
    //     var con = await connect();

    //     con.onclose(() => {
    //         reconnect();
    //     });
    // });
</script>

<div style="overflow: hidden">
    <MessageLog />
    <Cursor />
</div>
