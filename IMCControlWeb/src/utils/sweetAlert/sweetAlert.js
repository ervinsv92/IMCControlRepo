import Swal from 'sweetalert2'

const showAlert = async({text, title = '', icon='info', isConfirm=false})=>{
    if(isConfirm){
        const res = await Swal.fire({
            icon,
            title,
            showCancelButton: true,
            text,
            confirmButtonColor: 'blue'
        });
        return res.isConfirmed;
    }else{
        await Swal.fire({
            icon,
            title,
            text,
            confirmButtonColor: 'blue'
        });

        return true;
    }
}

export {
    showAlert
}