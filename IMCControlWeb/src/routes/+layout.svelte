<script>
    import Navbar from '../components/Navbar.svelte';
    import {onAuthStateChanged} from 'firebase/auth';
    import {fireAuth} from '../utils/firebase/firebase.config';
    import {userStore} from '../store/store';

    onAuthStateChanged(fireAuth, (authUser)=>{
        $userStore = authUser;
        console.log($userStore)
    });
</script>
<Navbar />

<div class="container">
    <slot />    
</div>
