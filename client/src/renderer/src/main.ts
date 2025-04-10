import { mount } from 'svelte'

import './assets/main.css'

import App from './App.svelte'

const app = mount(App, {
  target: document.getElementById('app')!
})

// window.addEventListener("mouseover", (e) => {
//   var roomData = e.srcElement.attributes['data-room'];
//   if(roomData)
//   {
//     console.log(roomData.value);
//     connect().then((con) => {
//       con.invoke("GetRoom", roomData.value).then(res => {
//         const response = JSON.parse(res);
//         if(response.success)
//         {
//           console.log(response.data);
//         }
//       });
//     })
//   }
// });

// window.addEventListener("mousedown", (e) => {
//   var roomData = e.srcElement.attributes['data-room'];
//   if(roomData)
//   {
//     console.log(roomData.value);
//     connect().then((con) => {
//       con.invoke("GetRoom", roomData.value).then(res => {
//         const response = JSON.parse(res);
//         if(response.success)
//         {
//           con.invoke("SendInput", `walkto ${response.data.Name}`);
//         }
//       });
//     })
//   }
// });

// Ensure the file path is correct and the image is accessible in the build output.

import "./lib/connect"
import { connect } from './lib/connect';

export default app
