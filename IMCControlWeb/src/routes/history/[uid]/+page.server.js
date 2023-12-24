import {imcService} from '../../../services/imcService';

export async function load({params}) {
    const res = await imcService.getImcsUser(params.uid);

	return {
		historys:res
	};
}