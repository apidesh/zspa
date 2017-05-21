import { Component, Inject } from '@angular/core';
import { Http, Headers, RequestOptions } from '@angular/http';

@Component({
    selector: 'enterprise',
    templateUrl: './enterprise.component.html'
})

export class EnterpriseComponent {
    public dataList: Data[];
    public model = {
        id: '',
        name: ''
    };
    private originUrl = '';
    private http = null;
    private api = {
        getall: '/api/Enterprise/EnterpriseList',
        search: '/api/Enterprise/Search',
        entry: '/api/Enterprise/Entry'
    };
    constructor(http: Http, @Inject('ORIGIN_URL') originUrl: string) {
        this.http = http;
        this.originUrl = originUrl;
        this.dataList = [];
    }

    private getAllItem() {
        this.http.get(this.originUrl + this.api.getall).subscribe(result => {
            this.dataList = result.json() as Data[];
        });
    }

    public onSubmitGetList() {
        this.getAllItem();
    }

    public onSubmitSearch() {
        this.dataList = [];
        this.http.get(this.originUrl + this.api.search + '?id=' + this.model.id + '&name=' + this.model.name).subscribe(result => {
            this.dataList = result.json() as Data[];
        });
    }

    public onSubmitAddData() {
        let headers = new Headers({ 'Content-Type': 'application/json' });
        let options = new RequestOptions({ headers: headers });
        let item = {
            id: this.model.id,
            name: this.model.name
        };
        let body = JSON.stringify(item);
        this.http.post(this.originUrl + this.api.entry, body, options).subscribe(result => {
            var message = result.json();
            this.getAllItem();
        });
    }
}

interface Data {
    id: string;
    enterpriseID: string;
    enterpriseName: string;
    isActive: boolean;
    createDate: string;
    createBy: string;
    updateDate: string;
    updateBy: string;
}