import { Component, Inject } from '@angular/core';
import { Http } from '@angular/http';

@Component({
    selector: 'tickerpermissions',
    templateUrl: './tickerpermissions.component.html'
})
export class TickerPermissionsComponent {
    public vm: TickerPermissionsVM;
    private http: Http;
    private base: string;

    public getTickers() {
        let id = this.vm ? this.vm.selectedRoleId : "";
        this.http.get(this.base + 'api/TickerPermissions/PermissionBasedTickers?roleId=' + id
        ).subscribe(result => {
            let x = result.json() as TickerPermissionsVM;
            this.vm = x;
        }, error => console.error(error));
    }


    constructor(http: Http, @Inject('BASE_URL') baseUrl: string) {
        this.http = http;
        this.base = baseUrl;
        this.getTickers();
    }
}

type TickerPermissionsVM  = {
    roles: Role[];
    tickers: Ticker[];
    selectedRoleId: string; 
}

type Ticker = {
    id: string;
    tickerCode: string;
    index: string;
    price: number;
}

type Role = {
    id: string;
    rolename: string;
}

