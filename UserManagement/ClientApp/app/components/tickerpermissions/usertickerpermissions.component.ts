import { Component, Inject } from '@angular/core';
import { Http } from '@angular/http';

@Component({
    selector: 'usertickerpermissions',
    templateUrl: './usertickerpermissions.component.html'
})
export class UserTickerPermissionsComponent {
    public vm: UserTickerPermissionsVM;
    private http: Http;
    private base: string;

    public getTickers() {
        let id = this.vm ? this.vm.selectedUserId : "";
        this.http.get(this.base + 'api/TickerPermissions/UserPermissionBasedTickers?userId=' + id
        ).subscribe(result => {
            let x = result.json() as UserTickerPermissionsVM;
            this.vm = x;
        }, error => console.error(error));
    }


    constructor(http: Http, @Inject('BASE_URL') baseUrl: string) {
        this.http = http;
        this.base = baseUrl;
        this.getTickers();
    }
}

type UserTickerPermissionsVM  = {
    users: User[];
    tickers: Ticker[];
    selectedUserId: string; 
}

type Ticker = {
    id: string;
    tickerCode: string;
    index: string;
    price: number;
}

type User = {
    id: string;
    roleId: string;
    name: string;
}

