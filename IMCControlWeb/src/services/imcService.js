import {PUBLIC_URL_API} from '$env/static/public';
class ImcService{
    async calculateImc(weight, height){
        const res = await fetch(`${PUBLIC_URL_API}imc/calculateimc/${height}/${weight}`);
        const imcResult = await res.json();
        return imcResult;
    }
}

const imcService = new ImcService();
export {imcService};