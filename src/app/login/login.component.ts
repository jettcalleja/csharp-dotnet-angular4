import { Component, OnInit, ViewContainerRef } from '@angular/core';
import { Http } from '@angular/http';
import { Router, ActivatedRoute } from '@angular/router';
import { ToastsManager } from 'ng2-toastr/ng2-toastr';

import {
    FormGroup,
    FormControl,
    Validators
} from '@angular/forms';

@Component({
   templateUrl: './login.component.html'
})
export class LoginComponent implements OnInit {
    
    constructor(
        private _httpService: Http,
        private route: ActivatedRoute,
        private router: Router,
        private toastr: ToastsManager,
        vcr: ViewContainerRef
    ) { 
        this.toastr.setRootViewContainerRef(vcr);
    }
    
    private apiValues: string[] = [];
    private showDialog: Boolean = false;
    private bodyText: string;
    private returnUrl: string;

    // registration form
    private myform: FormGroup;
    private email: FormControl;
    private firstName: FormControl;
    private lastName: FormControl;
    private password: FormControl;

    // login form
    private loginform: FormGroup;
    private emailLogin: FormControl;
    private passwordLogin: FormControl;

    ngOnInit() {

        if (localStorage.getItem('currentUser')) {
            this.router.navigate(['/']);
        }

        this.returnUrl = this.route.snapshot.queryParams['returnUrl'] || '/';
        this.createFormControls();
        this.createForm();
    }

    createFormControls() {
        this.firstName = new FormControl('', Validators.required);
        this.lastName = new FormControl('', Validators.required);
        this.email = new FormControl('', [
            Validators.required,
            Validators.pattern("[^ @]*@[^ @]*")
        ]);
        this.password = new FormControl('', [
            Validators.required,
            Validators.minLength(8)
        ]);

        this.emailLogin = new FormControl('', Validators.required);
        this.passwordLogin = new FormControl('', Validators.required);
    }

    createForm() {
        this.myform = new FormGroup({
            email:     this.email,
            firstName: this.firstName,
            lastName:  this.lastName,
            password:  this.password
        });

        this.loginform = new FormGroup({
            email: this.emailLogin,
            password: this.passwordLogin
        });
    }

    login() {
        if (this.loginform.valid) {
            let formObj = this.loginform.getRawValue();
            this._httpService.post('/api/user/login', formObj)
                .subscribe(
                    data => { 
                        this.loginform.reset();
                        localStorage.setItem('currentUser', JSON.stringify(data));
                        this.router.navigate([this.returnUrl]);
                    },
                    error => {
                        if (error.status === 404) {
                            return this.toastr.warning('Account Not Found', '404');
                        }

                        this.toastr.error('Error in logging in.', 'Oops!');
                    }
                );
        }
    }

    onSubmit() {
        if (this.myform.valid) {
            let formObj = this.myform.getRawValue();
            this._httpService.post('/api/user', formObj)
                .subscribe(
                    data => { 
                        this.myform.reset();
                        this.showDialog = false;
                        this.toastr.success('Successfully registered', 'Success!');
                    },
                    error => this.toastr.error('Error in registering.', 'Oops!')
                );
        }
    }
}