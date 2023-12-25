<script>
    export let data;
    import dayjs from 'dayjs';
    import {imcService} from '../../../services/imcService';
    import {userStore} from '../../../store/store';
    import {showAlert} from '../../../utils/sweetAlert/sweetAlert';
    let historys = data.historys;
    
    async function deleteImc(id){
        if(!await showAlert({text:"Desea eliminar el IMC?", isConfirm:true})){
            return;
        }

        try {
            const res = await imcService.deleteImc(id);
            getImcUser();
        } catch (error) {
            console.log(error);
        }
    }

    async function getImcUser(){
        const res = await imcService.getImcsUser($userStore.uid);
        historys = res;
    }
</script>

<style>
    .scroll-horizontal{
        overflow-x: auto !important;
        /* min-width: 500px; */
        max-width: 100%;
    }

    table {
        width: 100%; /* Opcional: hace que la tabla ocupe todo el ancho disponible */
        /* Estilos adicionales para la tabla, como bordes, espaciado, etc. */
    }

    table th, table td{
        white-space: nowrap;
    }
</style>

<h1>Historial</h1>
<hr>
<div class="scroll-horizontal">


<table class="table table-striped">
    <thead>
        <th>Altura</th>
        <th>Peso</th>
        <th>Imc</th>
        <th>Imc Descripción</th>
        <th>Fecha</th>
        <th>Eliminar</th>
    </thead>
    <tbody>
        {#if historys.length > 0}
            {#each historys as imc}
                <tr>
                    <td>{imc.height}</td>
                    <td>{imc.weight}</td>
                    <td>{imc.imc}</td>
                    <td>{imc.imcDescription}</td>
                    <td>{dayjs(imc.timesTamp).format("DD/MM/YYYY HH:mm")}</td>
                    <td><button type="button" class="btn btn-danger" on:click={()=>deleteImc(imc.id)}>X</button></td>
                </tr>
            {/each}
        {:else}
                <tr>
                    <td colspan="6">No hay datos para mostrar</td>
                </tr>
        {/if}
        
    </tbody>
</table>
</div>