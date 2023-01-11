import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { AccountService, ChangePasswordResponse } from 'src/app/services/account.service';
import { PublicationService } from 'src/app/services/publication.service';
import { ThrottlingExecutor } from 'src/app/shared/throttler';
import { PublicationResponse } from 'src/app/services/publication.service';
import {PageEvent} from '@angular/material/paginator';

@Component({
  selector: 'app-view-publications',
  templateUrl: './view-publications.html',
  styleUrls: ['./view-publications.scss']
})
export class ViewPublicationsComponent implements OnInit {

  public throttler = new ThrottlingExecutor(300);
  public filter: string;
  public publications: PublicationResponse[] | null;

  length: number | undefined;
  pageSize = 8;
  pageIndex = 0;
  pageSizeOptions = [8, 24, 48];

  constructor(
    private publicationService: PublicationService) { }

  public async ngOnInit(): Promise<void> {
    this.publications = await this.publicationService.getPublications('');
    this.length = this.publications?.length;
    this.publications = await this.publicationService.getPublications('', 1, this.pageSize);
  }

  public async handlePageEvent(e: PageEvent) {
    this.length = e.length;
    this.pageSize = e.pageSize;
    this.pageIndex = e.pageIndex;

    console.log(e);
    this.publications = await this.publicationService.getPublications(this.filter, e.pageIndex + 1, e.pageSize);
  }

  public async searchPublications(filter: string) {
    this.throttler.schedule(async () => {
      this.filter = filter;
      this.publications = await this.publicationService.getPublications(filter, 1, this.pageSize);
      this.length = this.publications?.length;
    });
  }
}
