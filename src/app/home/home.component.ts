import { Component, OnInit, ViewContainerRef } from '@angular/core';
import { Http } from '@angular/http';
import { Router } from '@angular/router';

import { FormGroup } from '@angular/forms';

import { ToastsManager } from 'ng2-toastr/ng2-toastr';

@Component({
   templateUrl: './home.component.html'
})
export class HomeComponent implements OnInit {
    
    constructor(
        private _httpService: Http, 
        private router: Router,
        private toastr: ToastsManager,
        vcr: ViewContainerRef
    ) { 
        this.toastr.setRootViewContainerRef(vcr);
    }
    
    private topics: JSON[] = [];
    private model: any = {};
    private opt: string = 'Add';
    private showDialog: boolean = false;

    ngOnInit() {
        this._httpService.get('/api/topic').subscribe(values => {
            this.topics = values.json() as JSON[];
        });
    }

    addTopic() {
        this._httpService.post('/api/topic', this.model)
            .subscribe(values => {
                this.toastr.success('Successfully added post', 'Successful!');
                this.showDialog = false;
                this.ngOnInit();
            }, error => {
                this.toastr.error('Error in adding post.', 'Oops!');
            });
    }

    edit() {
        this.showDialog = true;
        this._httpService.put('/api/topic/' + this.model.id , this.model)
            .subscribe(values => {
                this.toastr.success('Successfully edited post', 'Successful!');
                this.showDialog = false;
                this.ngOnInit();
            }, error => {
                this.toastr.error('Error in editing post.', 'Oops!');
            });
    }
        
    delete(id) {
        this._httpService.delete('/api/topic/' + id)
            .subscribe(values => {
                this.toastr.success('Successfully deleted post', 'Successful!');
                this.ngOnInit();
            }, error => {
                this.toastr.error('Error in deleting post.', 'Oops!');
            });
    }
    
    logout() {
        localStorage.removeItem('currentUser');
        this.router.navigate(['/login']);
    }
}