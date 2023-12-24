<script>
    import {imcService} from '../services/imcService';
    import {userStore} from '../store/store';
    import {showAlert} from '../utils/sweetAlert/sweetAlert';
	export let data;
    const {imcOptions} = data;
    const imcForm = {
        height:0,
        weight:0
    }
    let imcResult = null;
    
    async function calculateImc(){
        if(isNaN(imcForm.weight) || isNaN(imcForm.height) || imcForm.weight == 0 || imcForm.height == 0){
            showAlert({text:"El peso y la altura debe de ser un número mayor a 0"});
            return;
        }
        const imcRes = await imcService.calculateImc(imcForm.weight, imcForm.height);
        imcResult=imcRes;
    }

    function resultClean(){
        imcResult = null;
    }

    async function saveImc(){
        try {
            const res = await imcService.saveImc({
                Uuid:$userStore.uid,
                Height:imcForm.height,
                Weight:imcForm.weight,
                Imc:imcResult.imc,
                ImcDescription: imcResult.imcDescription,
                ImcColor:imcResult.color
            });
            resultClean();
            showAlert({text:"Imc guardado!"})
        } catch (error) {
            console.error(error);
        }
    }
</script>

<style>
    .note-alert{
        color:blue;
    }
</style>

<div class="row mt-2">
    <div class="col-lg-6 col-sm-12 col-xs-12">
        <h1>IMC</h1>
        <p>El Índice de Masa Corporal (IMC) es una medida que evalúa la relación entre el peso y la estatura de una persona. Se calcula dividiendo el peso en kilogramos por el cuadrado de la estatura en metros (IMC = peso / estatura^2). El IMC se usa comúnmente como indicador general de la cantidad de grasa corporal y ayuda a clasificar a las personas en categorías como bajo peso, peso normal, sobrepeso u obesidad, aunque no considera otros factores como la composición corporal o la distribución de la grasa.</p>
        <hr>
        <h2>Tabla del IMC</h2>
        <table class="table table-striped">
            <thead>
                <tr>
                    <th>Detalle</th>
                    <th>Condición</th>
                </tr>
            </thead>
            <tbody>
                {#each imcOptions as option}
                    <tr>
                        <td>{option.description}</td>
                        {#if option.min == 0}
                            <td>&lt;{ option.min ==0?option.max:option.min}</td>
                        {:else if option.max == 99}
                            <td>&gt;{option.min}</td>
                        {:else}
                            <td>&gt;{option.min} y &lt;{option.max} </td>
                        {/if}
                        
                    </tr>
                {/each}
                
            </tbody>
            
        </table>
    </div>
    <div class="col-lg-6 col-sm-12 col-xs-12">
        <h2>Calculadora IMC</h2>
        <div class="row mt-2">
            <div class="col-lg-12">
                <label>Peso:</label>
                <input bind:value={imcForm.weight} on:keypress={resultClean} type="text" placeholder="Peso" class="form-control">
            </div>
        </div>
        <div class="row mt-2">
            <div class="col-lg-12">
                <label>Altura(centimetros):</label>
                <input bind:value={imcForm.height} on:keypress={resultClean} type="text" placeholder="Altura (centimetros)" class="form-control">
            </div>
        </div>
        <div class="row mt-2">
            <div class="col-lg-12">
                <button type="button" class="btn btn-success form-control" on:click={calculateImc}>Calcular</button>
            </div>
        </div>
        <i class="note-alert">Inicia sesión para guardar tus resultados</i>
        {#if imcResult}
            <div class="row mt-2">
                <div class="col-lg-12">
                    <div class="alert" role="alert" style="background-color:{imcResult.color};">
                        {`El resultado de tu IMC es: ${imcResult.imc} por lo tanto tu condición es: ${imcResult.imcDescription}`}
                    </div>              
                </div>
            </div>
            {#if $userStore}
                <div class="row mt-1">
                    <div class="col-lg-12">
                        <button type="button" class="btn btn-primary form-control" on:click={saveImc}>Guardar</button>
                    </div>
                </div>            
            {/if}
        {/if}
        
    </div>
</div>
