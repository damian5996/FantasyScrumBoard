export interface DataWrapper<D> {
  isLoading: boolean;
  data: D[];
  error: any;
}
