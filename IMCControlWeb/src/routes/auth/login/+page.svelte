<script>
    import {fireAuth} from '../../../utils/firebase/firebase.config';
    import {GoogleAuthProvider, signInWithEmailAndPassword, signInWithPopup} from 'firebase/auth';
    import {goto} from '$app/navigation';
    import {showAlert} from '../../../utils/sweetAlert/sweetAlert';

    const loginForm = {
        email:'',
        password:''
    }

    let {email, password} = loginForm;

    const login = ()=>{
    if(email.trim() == ''){
        showAlert({text:"Debe ingresar un correo valido",icon: 'warning'});
        return;
    }else if(password.trim()==''){
        showAlert({text:"La contrasenia no puede estar vacia",icon: 'warning'});
        return;
    }
    
    signInWithEmailAndPassword(fireAuth, email, password)
    .then((userCredential) => {
        const user = userCredential.user;
        if(!user.emailVerified){
          showAlert({text:'Debe verificar el correo para continuar', icon:'info'});
        }else{
          goto('/')
        }
    })
    .catch((error) => {
        if(error.message.includes('invalid-email')){
          showAlert({text:'Debe ingresar un correo valido', icon:'error'});
        }else if(error.message.includes('wrong-password')){
          showAlert({text:'Clave incorrecta', icon:'error'});
        }else if(error.message.includes('invalid-credential')){
          showAlert({text:'Credenciales incorrectos', icon:'error'});
        }
        else{
          console.error(error.message);
          showAlert({text:'Ups, algo salio mal', icon:'error'});
        }
    });
}

    async function loginWithGoogle(){
        try {
            const provider = new GoogleAuthProvider();
            await signInWithPopup(fireAuth, provider);    
            goto('/');
        } catch (error) {
            console.error(error);
        }
    }
</script>

<div class='container'>
    <div class="row mt-2 d-flex justify-content-center align-items-center height100">
      <div class="col-lg-3">
      <div class="card">
        <div class="card-header text-center">
          <h5>IMC Control</h5>
          <i></i>
          <hr />
          <h6>Iniciar sesión</h6>
        </div>
        <div class="card-body">
          <div class='row mt-2'>
            <div class="col-lg-12">
            <div class="input-group mb-3">
              <span class="input-group-text" id="basic-addon1">
                <svg xmlns="http://www.w3.org/2000/svg" width="20" height="20" fill="currentColor" class="bi bi-envelope-fill" viewBox="0 0 16 16">
                  <path d="M.05 3.555A2 2 0 0 1 2 2h12a2 2 0 0 1 1.95 1.555L8 8.414.05 3.555ZM0 4.697v7.104l5.803-3.558L0 4.697ZM6.761 8.83l-6.57 4.027A2 2 0 0 0 2 14h12a2 2 0 0 0 1.808-1.144l-6.57-4.027L8 9.586l-1.239-.757Zm3.436-.586L16 11.801V4.697l-5.803 3.546Z"/>
                </svg>
              </span>
              <input type="text" class="form-control" bind:value={email} placeholder="Correo" aria-label="Correo" aria-describedby="basic-addon1" />
            </div>
            </div>
          </div>
          <div class='row mt-2'>
            <div class="col-lg-12">
            <div class="input-group mb-3">
              <span class="input-group-text" id="basic-addon1">
                <svg xmlns="http://www.w3.org/2000/svg" width="20" height="20" fill="currentColor" class="bi bi-key-fill" viewBox="0 0 16 16">
                  <path d="M3.5 11.5a3.5 3.5 0 1 1 3.163-5H14L15.5 8 14 9.5l-1-1-1 1-1-1-1 1-1-1-1 1H6.663a3.5 3.5 0 0 1-3.163 2zM2.5 9a1 1 0 1 0 0-2 1 1 0 0 0 0 2z"/>
                </svg>
              </span>
              <input type="password" class="form-control" bind:value={password} placeholder="Clave" aria-label="Clave" aria-describedby="basic-addon1" />
            </div>
            </div>
          </div>
          <div class='row mt-2'>
            <div class='col-12'>
              <button class='btn btn-outline-primary form-control' on:click={login}>Ingresar</button>
            </div>
          </div>

          <div class='row mt-2'>
            <div class='col-12 text-center'>
                <a href="/auth/recovery">Recuperar clave</a>
            </div>
          </div>

          <div class='row mt-2'>
            <div class='col-12 text-center'>
                <a href="/auth/register">Crear cuenta</a>
            </div>
          </div>

          <hr />

          <div class='row mt-2'>
            <div class='col-12'>
              <button class='btn btn-primary form-control' on:click={loginWithGoogle}>
                <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-google" viewBox="0 0 16 16">
                  <path d="M15.545 6.558a9.42 9.42 0 0 1 .139 1.626c0 2.434-.87 4.492-2.384 5.885h.002C11.978 15.292 10.158 16 8 16A8 8 0 1 1 8 0a7.689 7.689 0 0 1 5.352 2.082l-2.284 2.284A4.347 4.347 0 0 0 8 3.166c-2.087 0-3.86 1.408-4.492 3.304a4.792 4.792 0 0 0 0 3.063h.003c.635 1.893 2.405 3.301 4.492 3.301 1.078 0 2.004-.276 2.722-.764h-.003a3.702 3.702 0 0 0 1.599-2.431H8v-3.08h7.545z"/>
                </svg>
              </button>
            </div>
          </div>
        </div>
      </div>
      </div>
    </div>  
  </div>