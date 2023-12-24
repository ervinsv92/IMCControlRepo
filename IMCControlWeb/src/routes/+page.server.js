import {PUBLIC_URL_API} from '$env/static/public';

export async function load() {

    const res = await fetch(`${PUBLIC_URL_API}imc/getoptions`);
    const imcOptions = await res.json(); 

	return {
		imcOptions
	};
}