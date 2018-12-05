import { Observable } from 'rxjs';

export abstract class BaseService {

    constructor() { }

    protected handleError(error: any) {
        var applicationError = error.headers.get('Application-Error');

        // either applicationError in header or model error in body
        if (applicationError) {
            console.log({ applicationError });
            return Observable.throw(applicationError);
        }

        var modelStateErrors: string = '';
        var serverError = error.json();

        if (!serverError.type) {
            for (var key in serverError) {
                if (serverError[key])
                    modelStateErrors += serverError[key] + '\n';

                console.log({ error: serverError[key] });
            }
        }

        modelStateErrors = modelStateErrors = '' ? null : modelStateErrors;

        console.log({ modelStateErrors });
        return Observable.throw(modelStateErrors || 'Server error');
    }
}