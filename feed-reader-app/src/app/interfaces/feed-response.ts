import { FeedData } from './feed-data';

export interface FeedResponse {
  isLatest: boolean;
  feed: FeedData[];
}
