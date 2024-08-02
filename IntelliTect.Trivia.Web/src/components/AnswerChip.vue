<template>
  <v-chip class="mx-1" :color="color">
    {{ answer.text }}
  </v-chip>
</template>

<script setup lang="ts">
import { AnswerViewModel, QuestionViewModel } from "@/viewmodels.g";

const props = defineProps<{
  question: QuestionViewModel;
  answer: AnswerViewModel;
  color: string;
}>();
</script>
