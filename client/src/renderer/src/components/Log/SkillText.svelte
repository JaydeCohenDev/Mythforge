<script lang="ts">
    import { connect } from '../../lib/connect';
    import { setCursor } from '../../lib/cursor';
    import { createTooltip, removeTooltip } from '../../lib/tooltip';

    const { data, children } = $props();

    const click = (e) => {
        e.preventDefault();

        console.log(data);
        connect().then((con) => {
            con.invoke('SendInput', `skill ${data.Name}`);
        });
    };

    const tooltip = (el: HTMLElement) => {
        var tooltip;
        el.addEventListener('mouseenter', () => {
            tooltip = createTooltip(data.Icon + data.Name + '<br/><br/>' + data.Description);
        });
        el.addEventListener('mouseleave', () => {
            removeTooltip(tooltip);
        });
    };
</script>

<span
    >{data.Icon}
    <span use:tooltip class="skill" use:setCursor={'pointer'} onclick={click}>{data.Name}</span
    >{String(data.Name).padEnd(20).replace(data.Name, '')}</span
>{@render children?.()}

<style>
    .skill {
        color: white;
        text-decoration-style: none;
    }

    .skill:hover {
        text-decoration-line: underline;
        text-decoration-style: solid;
    }
</style>
