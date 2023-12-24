<script>
    export let data;
    import dayjs from 'dayjs' // ES 2015
    const {historys}=data;
</script>
<h1>Historial</h1>
<hr>
<table class="table table-striped">
    <thead>
        <th>Altura</th>
        <th>Peso</th>
        <th>Imc</th>
        <th>Imc Descripcion</th>
        <th>Fecha</th>
        <th>Eliminar</th>
    </thead>
    <tbody>
        {#each historys as imc}
            <tr>
                <td>{imc.height}</td>
                <td>{imc.weight}</td>
                <td>{imc.imc}</td>
                <td>{imc.imcDescription}</td>
                <td>{dayjs(imc.timesTamp).format("DD/MM/YYYY HH:mm")}</td>
                <td><button type="button" class="btn btn-danger">X</button></td>
            </tr>
        {/each}
    </tbody>
</table>
