<script lang="ts">
    import { mount, onDestroy, onMount } from 'svelte';
    import { connect } from '../lib/connect';
    import LogMessage from '../components/Log/LogMessage.svelte';
    import { setCursor } from '../lib/cursor';
    import OptionsSelection from '../components/Log/OptionsSelection.svelte';

    var userInput = $state('');
    var messagesEl: HTMLElement;
    var inputEl: HTMLInputElement;

    const history: string[] = [];
    var historyIndex = 0;

    const showMessage = (message) => {
        mount(LogMessage, {
            target: messagesEl,
            props: {
                content: message
            }
        });
    };

    const initializeConnection = async () => {
        connect()
            .then((con) => {
                const resizeObserver = new ResizeObserver(() => {
                    messagesEl.parentElement.scrollTo(0, messagesEl.parentElement.scrollHeight);
                });

                resizeObserver.observe(messagesEl);

                con.onclose(() => {
                    showMessage('Disconnected from server.');
                });

                con.onreconnecting(() => {
                    showMessage('Reconnecting to server...');
                });

                con.onreconnected(() => {
                    showMessage('Reconnected.');
                });

                con.on('ShowMessage', (message) => {
                    showMessage(message);
                });

                con.on('ShowOptions', async (options) => {
                    console.log(options);
                    let prom = new Promise((resolve, _) => {
                        console.log('WORKD!');
                        const callback = (selection) => {
                            console.log(selection);
                            resolve(selection);
                        };

                        mount(OptionsSelection, {
                            target: messagesEl,
                            props: {
                                options,
                                callback
                            }
                        });
                    });

                    return prom;
                });
            })
            .catch((err) => {
                showMessage('Unable to connect to server. Retrying in 5s');
                console.log('connection failed, retrying', err);
                setTimeout(() => {
                    initializeConnection();
                }, 5000);
            });
    };

    const keyEvent = (e) => {
        focusInput();

        if (e.key === 'ArrowUp') {
            userInput = history[history.length - historyIndex - 1];
            historyIndex++;
        } else if (e.key == 'ArrowDown') {
            userInput = history[history.length - historyIndex - 1];
            historyIndex--;
        }
    };

    onMount(async () => {
        await initializeConnection();

        window.addEventListener('keydown', keyEvent);
    });

    onDestroy(() => {
        window.removeEventListener('keydown', keyEvent);
    });

    const submit = async (e) => {
        e.preventDefault();
        if (userInput === '') return;

        var con = await connect();

        showMessage(`<span class='user-input'>> ${userInput}</span>`);
        await con.invoke('SendInput', userInput);
        history.push(userInput);
        historyIndex = 0;

        userInput = '';
    };

    const focusInput = () => {
        console.log('test');
        inputEl.focus();
    };
</script>

<!-- svelte-ignore a11y_no_noninteractive_element_interactions -->
<!-- svelte-ignore a11y_no_static_element_interactions -->
<div class="panel">
    <div class="message-log">
        <div class="messages" bind:this={messagesEl}></div>
    </div>
    <form class="input-row" onsubmit={submit}>
        <input
            bind:this={inputEl}
            use:setCursor={'input'}
            type="text"
            placeholder=">"
            bind:value={userInput}
        />
    </form>
</div>

<style>
    .message-log {
        flex-grow: 1;
        overflow-y: scroll;
        overflow-x: hidden;
        scrollbar-color: #222 #111;
        scroll-behavior: smooth;
        color: rgb(221, 221, 221);
        font-size: 20px;
        letter-spacing: 1px;
    }
    .messages {
        padding: 20px;
    }
    .input-row {
        display: flex;
        flex-direction: row;
    }
    input {
        width: 100%;
        background-color: transparent;
        font-size: 20px;
        border: none;
        outline: none;
        color: white;
        padding: 10px 20px;
    }
    .panel {
        width: 100vw;
        height: 100vh;
        overflow: hidden;
        display: flex;
        flex-direction: column;
    }
</style>
