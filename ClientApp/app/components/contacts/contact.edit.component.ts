import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Location } from '@angular/common';
import { Http, Headers, RequestOptions } from '@angular/http';

@Component({
    templateUrl: './contact.edit.component.html'
})
export class ContactEditComponent implements OnInit {

    //might need to be any
    public contact: Contact;

    public constructor(private http: Http, private route: ActivatedRoute, private location: Location) {
        this.contact = {
            "id": 0,
            "name": "",
            "address": "",
            "city": "",
            "state": "",
            "zip": "",
            "email": ""
        } as Contact;
    } 

    public ngOnInit() {
        this.route.params.subscribe(params => {
            if(params["id"] && params["id"] > 0) {
                this.http.get("/api/contacts/" + params["id"])
                    .subscribe(results => {
                        this.contact = results.json() as Contact;
                    }, error => {
                        console.error(error);
                    });
            }
        });
    }

    public save() {
        let headers = new Headers({ 'Content-Type': 'application/json' });
        let options = new RequestOptions({ headers: headers });
        let promise;
        
        if (this.contact.id === 0 ) {
            promise = this.http.post("/api/contacts", JSON.stringify(this.contact), options);
        } else {
            promise = this.http.put("/api/contacts/" + this.contact.id, JSON.stringify(this.contact), options);
        }
        
        promise.subscribe(results => {
            this.location.back();
        }, error => {
            console.error(error);
        });
    }

}

interface Contact {
    id: number;
    name: string;
    address: string;
    city: string;
    state: string;
    zip: string;
    email: string;
}