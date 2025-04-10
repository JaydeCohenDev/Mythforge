<script lang="ts">
    import { onMount } from 'svelte';
    import { onCursorChanged } from '../lib/cursor';

    import Default from '../assets/cursors/gauntlet_default.png';
    import Pointer from '../assets/cursors/gauntlet_point.png';
    import Walk from '../assets/cursors/steps.png';
    import Input from '../assets/cursors/bracket_b_vertical.png';

    var cursorSrc = $state(Default);
    var cursorEl: HTMLElement;

    const mouseMove = (e: MouseEvent) => {
        cursorEl.style.left = `${e.clientX}px`;
        cursorEl.style.top = `${e.clientY}px`;
    };

    const mouseLeave = () => {
        console.log('leave');
        cursorEl.style.visibility = 'hidden';
    };

    const mouseEnter = () => {
        cursorEl.style.visibility = 'visible';
    };

    onMount(() => {
        onCursorChanged.push((cursor) => {
            switch (cursor) {
                case 'default':
                    cursorSrc = Default;
                    break;
                case 'pointer':
                    cursorSrc = Pointer;
                    break;
                case 'walk':
                    cursorSrc = Walk;
                    break;
                case 'input':
                    cursorSrc = Input;
                    break;
            }
        });

        window.addEventListener('mousemove', mouseMove);
        document.addEventListener('mouseleave', mouseLeave);
        document.addEventListener('mouseenter', mouseEnter);

        return () => {
            window.removeEventListener('mousemove', mouseMove);
            document.removeEventListener('mouseleave', mouseLeave);
            document.removeEventListener('mouseenter', mouseEnter);
        };
    });
</script>

<div bind:this={cursorEl} class="cursor">
    <img src={cursorSrc} />
</div>

<style>
    .cursor {
        pointer-events: none;
        position: absolute;
        z-index: 1000;
        left: 0;
        top: 0;
    }
    img {
        width: 32px;
        height: 32px;
    }
</style>
