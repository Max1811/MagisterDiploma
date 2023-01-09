import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { AccountService, ChangePasswordResponse } from 'src/app/services/account.service';
import { PublicationService } from 'src/app/services/publication.service';
import { ThrottlingExecutor } from 'src/app/shared/throttler';
import { PublicationResponse } from 'src/app/services/publication.service';

@Component({
  selector: 'app-view-publications',
  templateUrl: './view-publications.html',
  styleUrls: ['./view-publications.scss']
})
export class ViewPublicationsComponent implements OnInit {

  public throttler = new ThrottlingExecutor(300);
  public filter: string;
  public publications: PublicationResponse[] | null;

  constructor(
    private router: Router,
    private publicationService: PublicationService,
    private route: ActivatedRoute) { }

  public async ngOnInit(): Promise<void> {
    this.publications = await this.publicationService.getPublications('');
  }

  public async searchPublications(filter: string) {
    this.throttler.schedule(async () => {
      this.publications = await this.publicationService.getPublications(filter);
    });
}

  public async onSubmit(): Promise<void> {

  }
}
