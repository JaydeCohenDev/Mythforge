import { existsSync, mkdirSync, writeFileSync } from "fs";
import { join } from "path";

const scriptsFolder = join(__dirname, "../../scripts");

export function UpdateLocalScript(script)
{
    if(!existsSync(scriptsFolder))
    {
        mkdirSync(scriptsFolder);
    }
    
    const filePath = join(scriptsFolder, `${script.Name}.cs`);
    
    try {
        writeFileSync(filePath, script.SourceCode, 'utf8');
        console.log(`Script saved to ${filePath}`);
    } catch(error) {
        console.error("failed to save the script:", error);
    }
}