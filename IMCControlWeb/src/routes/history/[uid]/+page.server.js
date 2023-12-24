import {imcService} from '../../../services/imcService';

export async function load({params}) {
    const res = await imcService.getimcsuser(params.uid);

	return {
		historys:res
	};
}