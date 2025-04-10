import { mount, unmount } from "svelte";
import Tooltip from "../components/Tooltip/Tooltip.svelte";

export function createTooltip(content)
{
    return mount(Tooltip, {
        target: document.body,
        props: {
            content
        }
    })
}

export function removeTooltip(tooltip: Record<string, any>)
{
    unmount(tooltip);
}