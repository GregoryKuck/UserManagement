import { Component, Inject } from '@angular/core';
import { Http } from '@angular/http';

@Component({
    selector: 'usersroles',
    templateUrl: './usersroles.component.html'
})
export class UsersRolesComponent {
    private http: Http;
    private base: string;

    public vm: UsersRolesVM;
    
    public assignRoleToUser() {
        let userId = this.vm.selectedUserId;
        let roleId = this.vm.selectedRoleId;

        this.http.get(this.base + 'api/UsersRoles/SetUserRole?userId=' + userId + '&roleId=' + roleId
        ).subscribe(result => {
            //let x = result.json() as UsersRolesVM;
            //this.vm = x;
        }, error => console.error(error));
    }

    public getUsersAndRoles() {
        this.http.get(this.base + 'api/UsersRoles/GetUsersAndRoles'
        ).subscribe(result => {
            let x = result.json() as UsersRolesVM;
            this.vm = x;
        }, error => console.error(error));
    }


    constructor(http: Http, @Inject('BASE_URL') baseUrl: string) {
        this.http = http;
        this.base = baseUrl;
        this.getUsersAndRoles();
    }
}

type UsersRolesVM  = {
    users: User[];
    roles: Role[];
    selectedRoleId: string;
    selectedUserId: string;
}

type User = {
    id: string;
    roleId: string;
    name: string;
}

type Role = {
    id: string;
    rolename: string;
}

