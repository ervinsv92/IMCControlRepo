<script>
    import {fireAuth} from '../../../utils/firebase/firebase.config';
    import {createUserWithEmailAndPassword, sendEmailVerification} from 'firebase/auth';
    import {goto} from '$app/navigation';
    import {showAlert} from '../../../utils/sweetAlert/sweetAlert';

    const registerForm = {
        email:'',
        password:'',
        passwordConfirm:''
    }

    let {email, password, passwordConfirm} = registerForm;

    const register = ()=>{
        if(email.trim() == ''){
            showAlert({text:'Debe ingresar un correo valido', icon:'warning'});
            return;
        }else if(password.trim()==''){
            showAlert({text:'La contrasenia no puede estar vacia', icon:'warning'});
            return;
        }else if(password.trim().length < 6){
              showAlert({text:'La clave debe tener 6 o mas caracteres', icon:'warning'});
              return;
        }else if(password.trim() != passwordConfirm.trim()){
            showAlert({text:'Las contrasenias deben ser iguales', icon:'warning'});
            return;
        }

        createUserWithEmailAndPassword(fireAuth, email, password).then(async (userCredential)=>{
          await sendEmailVerification(fireAuth.currentUser);
          await showAlert({text:'Se le ha enviado un correo de verificación, verifiquelo y proceda a iniciar sesión',title:'Verificación'});
          goto('/auth/login')
        }).catch((error)=>{
            if(error.message.includes('email-already-in-use')){
              showAlert({text:'El correo ingresado ya existe', icon:'error'});
            }else if(error.message.includes('invalid-email')){
              showAlert({text:'Debe ingresar un correo valido', icon:'error'});
            }else if(error.message.includes('weak-password')){
              showAlert({text:'La clave debe tener 6 o mas caracteres', icon:'error'});
            }
            else{
              console.error(error.message);
              showAlert({text:'Ups, algo salio mal', icon:'error'});
            }
        });
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
          <h6>Crear cuenta</h6>
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
                <svg xmlns="http://www.w3.org/2000/svg" width="18" height="20" fill="currentColor" class="bi bi-key-fill" viewBox="0 0 16 16">
                  <path d="M3.5 11.5a3.5 3.5 0 1 1 3.163-5H14L15.5 8 14 9.5l-1-1-1 1-1-1-1 1-1-1-1 1H6.663a3.5 3.5 0 0 1-3.163 2zM2.5 9a1 1 0 1 0 0-2 1 1 0 0 0 0 2z"/>
                </svg>
              </span>
              <input type="password" class="form-control" bind:value={password} placeholder="Clave" aria-label="Clave" aria-describedby="basic-addon1" />
            </div>
            </div>
          </div>
          <div class='row mt-2'>
            <div class="col-lg-12">
            <div class="input-group mb-3">
              <span class="input-group-text" id="basic-addon1">
                <svg xmlns="http://www.w3.org/2000/svg" width="18" height="20" fill="currentColor" class="bi bi-key-fill" viewBox="0 0 16 16">
                  <path d="M3.5 11.5a3.5 3.5 0 1 1 3.163-5H14L15.5 8 14 9.5l-1-1-1 1-1-1-1 1-1-1-1 1H6.663a3.5 3.5 0 0 1-3.163 2zM2.5 9a1 1 0 1 0 0-2 1 1 0 0 0 0 2z"/>
                </svg>
              </span>
              <input type="password" class="form-control" bind:value={passwordConfirm} placeholder="Confirmar clave" aria-label="Clave" aria-describedby="basic-addon1" />
            </div>
            </div>
          </div>
          <div class='row mt-2'>
            <div class='col-12'>
              <button class='btn btn-outline-primary form-control' on:click={register}>Crear cuenta</button>
            </div>
          </div>

          <div class='row mt-4'>
            <div class='col-12 text-center'>
                <a href="/auth/login">Inicio de sesión</a>
            </div>
          </div>
        </div>
      </div>
      </div>
    </div>  
  </div>