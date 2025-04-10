type CursorType = "default" | "pointer" | "walk" | "input"

export let CurCursorType: CursorType = "default";
export const onCursorChanged:((cursor: CursorType) => void)[] = []; 

export function setCursor(el: HTMLElement, cursorType: CursorType)
{
    el.addEventListener("mouseenter", () => {
        CurCursorType = cursorType;
        onCursorChanged.forEach((cb) => {
            cb(cursorType);
        });
    });
    
    el.addEventListener("mouseleave", () => {
        CurCursorType = 'default';
        onCursorChanged.forEach((cb) => {
            cb(CurCursorType);
        });
    })
    
    
}