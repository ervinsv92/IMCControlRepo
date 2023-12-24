<script>
    import {fireAuth} from '../../../utils/firebase/firebase.config';
    import {GoogleAuthProvider, signInWithPopup} from 'firebase/auth';
    import {goto} from '$app/navigation';

    async function login(){
        try {
            const provider = new GoogleAuthProvider();
            await signInWithPopup(fireAuth, provider);    
            goto('/');
        } catch (error) {
            console.error(error);
        }
    }
</script>

<h1>login</h1>
<button on:click={login}>Login</button>