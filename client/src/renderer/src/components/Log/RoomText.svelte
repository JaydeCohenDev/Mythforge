<script lang="ts">
    import { connect } from '../../lib/connect';
    import { setCursor } from '../../lib/cursor';
    import { createTooltip, removeTooltip } from '../../lib/tooltip';

    const { data, children } = $props();

    const click = (e) => {
        e.preventDefault();

        console.log(data);
        connect().then((con) => {
            con.invoke('SendInput', `walkto ${data.Name}`);
        });
    };

    const tooltip = (el: HTMLElement) => {
        var tooltip;
        el.addEventListener('mouseenter', () => {
            tooltip = createTooltip(data.Name + '<br/><br/>' + data.Description);
        });
        el.addEventListener('mouseleave', () => {
            removeTooltip(tooltip);
        });
    };
</script>

<span class="room" use:tooltip use:setCursor={'pointer'} onclick={click}>{data.Name}</span
>{@render children?.()}

<style>
    .room {
        pointer-events: all;
        color: lime;
        text-decoration-style: none;
    }

    .room:hover {
        text-decoration-line: underline;
        text-decoration-style: solid;
    }
</style>
