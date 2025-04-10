<script lang="ts">
    import { connect } from '../../lib/connect';
    import { createTooltip, removeTooltip } from '../../lib/tooltip';

    const { data, children } = $props();

    const click = (e) => {
        e.preventDefault();

        console.log(data);
        connect().then((con) => {
            con.invoke('SendInput', `greet ${data.Name}`);
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

<span use:tooltip class="npc" onclick={click}>{data.Name}</span>{@render children?.()}

<style>
    .npc {
        color: yellow;
        text-decoration-style: none;
    }

    .npc:hover {
        text-decoration-line: underline;
        text-decoration-style: solid;
    }
</style>
