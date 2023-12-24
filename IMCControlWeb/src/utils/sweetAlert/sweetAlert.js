import Swal from 'sweetalert2'

const showAlert = ({text, title = '', icon='info'})=>{
    Swal.fire({
        icon,
        title,
        text,
        confirmButtonColor: 'blue'
      })
}

export {
    showAlert
}