<script lang="ts">
    import { DomUtil } from 'leaflet';
    import { mount, onMount, type Component } from 'svelte';
    import RoomText from './RoomText.svelte';
    import DenizenText from './DenizenText.svelte';
    import SkillText from './SkillText.svelte';
    import DialogueText from './DialogueText.svelte';
    import MobText from './MobText.svelte';

    const { content } = $props();

    var messageEl: HTMLDivElement;

    const componentMap: Map<string, Component> = new Map();
    componentMap.set('ROOM', RoomText);
    componentMap.set('NPC', DenizenText);
    componentMap.set('SKILL', SkillText);
    componentMap.set('DIALOGUE', DialogueText);
    componentMap.set('MOB', MobText);

    onMount(() => {
        const parser = new DOMParser();
        const doc = parser.parseFromString(`<message>${content}</message>`, 'text/html');

        const m: Map<string, [Component, {}]> = new Map();

        var id = 0;

        var walker = doc.createTreeWalker(doc.body);
        while (walker.nextNode()) {
            var node: HTMLElement = walker.currentNode as HTMLElement;
            if (componentMap.has(node.nodeName)) {
                var payload: string = atob(node.getAttribute('payload'));
                var data = JSON.parse(payload);
                var span = DomUtil.create('span');
                span.id = `id${id++}`;
                span.replaceChildren(...node.children);
                span.innerText = '';
                node.replaceWith(span);
                walker.currentNode = span;
                m.set(span.id, [componentMap.get(node.nodeName), data]);
            }
        }

        messageEl.innerHTML = doc.body.firstElementChild.innerHTML += '<br/><br/>';

        setTimeout(() => {
            m.forEach((val, key) => {
                const el = messageEl.querySelector(`#${key}`);
                mount(val[0], {
                    target: el,
                    props: {
                        data: val[1]
                    }
                });
            });
        }, 0);
    });
</script>

<div bind:this={messageEl}></div>
