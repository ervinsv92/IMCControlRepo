<script>
  import { onMount } from 'svelte';
  import {signOut} from 'firebase/auth';
  import {fireAuth} from '../utils/firebase/firebase.config';
  import {userStore} from '../store/store';
  import {goto} from '$app/navigation';
  
  async function logout(){
    try {
      await signOut(fireAuth)  
      goto("/");
    } catch (error) {
     console.error(error); 
    }
  }

  function gotoHistory(){
      closeMenuOnClick();
      goto(`/history/${$userStore.uid}`);
  }
  
  function closeMenuOnClick() {
    const menu = document.getElementById('navbarNav'); // Suponiendo que el menú tiene el id 'navbarNav'
    menu.classList.remove('show'); // Cierra el menú
  }

  onMount(() => {
    const menuLinks = document.querySelectorAll('#navbarNav .nav-link'); // Selecciona todos los enlaces del menú
    menuLinks.forEach(link => {
      link.addEventListener('click', closeMenuOnClick); // Agrega un listener para cerrar el menú al hacer clic
    });
  });
</script>

<nav class="navbar navbar-expand-lg bg-body-tertiary" collapseOnSelect>
    <div class="container-fluid">
      <a class="navbar-brand" href="/">IMC Control</a>
      <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarNav" aria-controls="navbarNav" aria-expanded="false" aria-label="Toggle navigation">
        <span class="navbar-toggler-icon"></span>
      </button>
      <div class="collapse navbar-collapse" id="navbarNav">
        <ul class="navbar-nav me-auto my-2 my-lg-0">
          <li class="nav-item">
            <a class="nav-link active" aria-current="page" href="/">Inicio</a>
          </li>
          {#if $userStore}
            <li class="nav-item">
              <a class="nav-link" href="#1" on:click|preventDefault={gotoHistory}>Historial</a>
            </li>
          {/if}
        </ul>
        {#if $userStore}
        <span class='d-flex justify-content-end'>{$userStore.email}&nbsp;
          <button class="btn btn-danger" on:click={logout}>
            <svg xmlns="http://www.w3.org/2000/svg" width="22" height="22" fill="currentColor" class="bi bi-box-arrow-right" viewBox="0 0 16 16">
              <path fillRule="evenodd" d="M10 12.5a.5.5 0 0 1-.5.5h-8a.5.5 0 0 1-.5-.5v-9a.5.5 0 0 1 .5-.5h8a.5.5 0 0 1 .5.5v2a.5.5 0 0 0 1 0v-2A1.5 1.5 0 0 0 9.5 2h-8A1.5 1.5 0 0 0 0 3.5v9A1.5 1.5 0 0 0 1.5 14h8a1.5 1.5 0 0 0 1.5-1.5v-2a.5.5 0 0 0-1 0v2z"/>
              <path fillRule="evenodd" d="M15.854 8.354a.5.5 0 0 0 0-.708l-3-3a.5.5 0 0 0-.708.708L14.293 7.5H5.5a.5.5 0 0 0 0 1h8.793l-2.147 2.146a.5.5 0 0 0 .708.708l3-3z"/>
            </svg>
          </button>
        </span>
        {:else}
            <a href="/auth/login" class="btn btn-outline-primary">Login</a>
        {/if}
      </div>
    </div>
  </nav>