import { Injectable } from "@angular/core";
import { CanActivate, Router } from "@angular/router";
import { Observable, of, catchError, switchMap, from } from "rxjs";
import { CurrentUserStorage } from "./current-user-storage";
import { AccountService, ICurrentUser } from "./services/account.service";

@Injectable()
export class LoggedInGuard implements CanActivate {
    constructor(
        private router: Router,
        private accountService: AccountService,
        private currentUserStorage: CurrentUserStorage) { }

    canActivate(): Observable<boolean> {
        return from(this.accountService.getCurrentUser()).pipe(switchMap((currentUser: ICurrentUser | null) => {
            if (!currentUser) {
                this.router.navigate(["/login"]);
                return of(false);
            }
            this.currentUserStorage.currentUser = currentUser;
            return of(true);
        }),
            catchError((error: any) => of(false)));
    }
}
