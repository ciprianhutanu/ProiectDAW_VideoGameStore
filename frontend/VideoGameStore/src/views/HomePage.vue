// components/HomePage.vue
<template>
  <div>
    <h2>Home Page</h2>
    <div v-for="item in itemsWithReview" :key="item.Title">
      <h3>{{ item.Title }}</h3>
      <p>{{ item.Description }}</p>
      <p>Price: {{ item.Price }}</p>
      <p>Score: {{ item.Score }}</p>
    </div>
  </div>
</template>

<script>
import { computed } from 'vue';
import { useStore } from 'vuex';

export default {
  name: 'HomePage',
  setup() {
    const store = useStore();

    store.dispatch('fetchItemsWithReview');

    const itemsWithReview = computed(() => store.getters.getItemsWithReview);

    return {
      itemsWithReview,
    };
  },
};
</script>


<style scoped>

</style>
