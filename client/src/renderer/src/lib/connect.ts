import * as SignalR from '@microsoft/signalr';

const connection = new SignalR.HubConnectionBuilder()
    .withUrl("http://localhost:5043/game")
    .withAutomaticReconnect()
    .build();
    
var curPromise: Promise<SignalR.HubConnection> | undefined;

export function IsConnected(): boolean {
    if(!connection) return false;
    return connection.state === SignalR.HubConnectionState.Connected;
}

export async function connect(): Promise<SignalR.HubConnection>
{
    if(connection.state == SignalR.HubConnectionState.Connected) 
        return connection;
    
    if(curPromise)
        return curPromise;
    
    curPromise = new Promise<SignalR.HubConnection>((resolve, reject) => {
        
        // const timeout = setTimeout(() => {
        //     reject(new Error("Connection timed out"));
        // }, 2000);

        
        connection.start().then(() => {
           // clearTimeout(timeout);
            console.log("Connected!");
            connection.on("disconnect", () => {
                connection.stop();
            });
            return resolve(connection);
        }).catch(err => {
            //clearTimeout(timeout);
            console.error(err);
            return reject(err);
        })
    });
    return curPromise;
}


    
    

    
    