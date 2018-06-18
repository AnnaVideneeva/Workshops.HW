import { Component, OnInit, Input } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-paging',
  templateUrl: './paging.component.html',
  styleUrls: ['./paging.component.css'],
  providers: [Location]
})
export class PagingComponent implements OnInit {

  // @Output() pageChanged = new EventEmitter<number>();
  page: number;
  displayPages: number[] = [];

  private _pageCount: number;
  public get pageCount(): number {
    return this._pageCount;
  }
  @Input() public set pageCount(v: number) {
    this._pageCount = v;
    this.setDisplayPages();
  }

  constructor(private route: ActivatedRoute, private router: Router) { }

  ngOnInit() {
    this.route.queryParamMap.subscribe(params =>
      this.onQueryParamsChanged(+params.get('page')));
  }

  onQueryParamsChanged(page: number) {
    if (page < 1) {
      page = 1;
      this.router.navigate([], {queryParams: {page: 1}, queryParamsHandling: 'merge', replaceUrl: true});
    }
    this.page = page;
    this.setDisplayPages();
  }

  setDisplayPages() {
    const displayCount = 5;
    this.displayPages = [];
    if (this.pageCount > 0) {
      this.displayPages.push(this.page);
      for (let index = 1; index <= displayCount - 1; index++) {
        if (this.page - index > 0) {
          this.displayPages.push(this.page - index);
        }
        if (this.page + index <= this.pageCount) {
          this.displayPages.push(this.page + index);
        }
        if (this.displayPages.length >= displayCount) {
          break;
        }
      }
      this.displayPages.sort((a, b) => a - b);
    }
  }
}
