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
        connection.start().then(() => {
            console.log("Connected!");
            return resolve(connection);
        }).catch(err => {
            console.error(err);
            return reject(err);
        })
    });
    return curPromise;
}


    
    

    
    