import {PUBLIC_URL_API} from '$env/static/public';
class ImcService{
    async calculateImc(weight, height){
        const res = await fetch(`${PUBLIC_URL_API}imc/calculateimc/${height}/${weight}`);
        const imcResult = await res.json();
        return imcResult;
    }

    async saveImc(imc){
        console.log("servicio", imc)
        const res = await fetch(`${PUBLIC_URL_API}imc/saveimc`,{
            method:'POST',
            headers:{
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(imc)
        })

        const imcResult = await res.json();
        return imcResult;
    }

    async getImcsUser(uuid){
        const res = await fetch(`${PUBLIC_URL_API}imc/getimcsuser/${uuid}`);
        const historyResult = await res.json();
        return historyResult;
    }

    async deleteImc(id){
        const res = await fetch(`${PUBLIC_URL_API}imc/deleteimc/${id}`,{
            method:'DELETE'
        })

        const imcResult = await res.json();
        return imcResult;
    }
}

const imcService = new ImcService();
export {imcService};