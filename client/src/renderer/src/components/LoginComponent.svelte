<script lang="ts">
    import { createEventDispatcher } from 'svelte';

    const dispatch = createEventDispatcher();
    let username = '';
    let password = '';

    const login = async () => {
        // Add your real auth logic here!
        const success = await fakeLogin(username, password);
        if (success) {
            localStorage.setItem('token', 'your-token'); // save token
            dispatch('loginSuccess');
        } else {
            alert('Login failed!');
        }
    };

    async function fakeLogin(username: string, password: string) {
        // Replace with your real auth system
        return username === 'admin' && password === 'password';
    }
</script>

<div class="login">
    <h2>Login</h2>
    <input placeholder="Username" bind:value={username} />
    <input placeholder="Password" type="password" bind:value={password} />
    <button on:click={login}>Login</button>
</div>

<style>
    .login {
        display: flex;
        flex-direction: column;
        justify-content: center;
        align-items: center;
        height: 100vh;
        color: white;
    }

    input {
        margin: 5px;
        padding: 8px;
        font-size: 16px;
    }

    button {
        padding: 8px 16px;
        font-size: 16px;
        margin-top: 10px;
    }
</style>
