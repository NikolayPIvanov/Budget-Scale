import { Injectable } from '@angular/core';

@Injectable()
export class ConfigService {

    protected _apiURI: string;

    constructor() {
        this._apiURI = 'https://localhost:5001/api';
    }

    getApiURI() {
        return this._apiURI;
    }
}